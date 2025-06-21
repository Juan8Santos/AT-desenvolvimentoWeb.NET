using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AT.Data;
using AT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AT.Pages.Reservas
{
    public class CreateModel : PageModel
    {
        private readonly AT.Data.EmpresaViagemContext _context;

        public CreateModel(AT.Data.EmpresaViagemContext context)
        {
            _context = context;
        }

        public decimal valorTotal { get; set; }
        public string Mensagem { get; set; }
        public string MensagemErro { get; set; }
        public TimeSpan Dias { get; set; }

        public Func<int, decimal, decimal> calcularValorTotal;

        public IActionResult OnGet()
        {
            calcularValorTotal = CalcularValorTotal;
            Options();
            return Page();
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var pacote = await _context.PacoteTuristico.FirstOrDefaultAsync(p => p.Id == Reserva.PacoteTuristicoId);

            if (pacote == null)
            {
                MensagemErro = "Pacote não encontrado.";
                Options();
                return Page();
            }

            if (Reserva.DataFinal < pacote.DataInicio)
            {
                Options();
                MensagemErro = "Erro! A data não pode ser no passado.";
                return Page();
            }

            if (pacote.Reservados >= pacote.CapacidadeMaxima)
            {
                Options();
                MensagemErro = "Erro! Limite de reservas atingido.";
                return Page();
            }

            var reservaExistente = await _context.Reservas.FirstOrDefaultAsync(r =>
            r.ClienteId == Reserva.ClienteId &&
            r.PacoteTuristicoId == Reserva.PacoteTuristicoId &&
            r.Datainicial == pacote.DataInicio);

            if (reservaExistente != null)
            {
                Options();
                MensagemErro = "Erro! Você já possui uma reserva neste pacote para essa data.";
                return Page();
            }

            pacote.AdicionarReserva();

            Reserva.Datainicial = pacote.DataInicio;
            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Reservas/Index");
        }

        public async Task<IActionResult> OnPostCalcularAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            calcularValorTotal = CalcularValorTotal;
            Options();

            await CalcularAsync();

            return Page();
        }

        public async Task<IActionResult> CalcularAsync()
        {
            var pacote = await _context.PacoteTuristico.FirstOrDefaultAsync(p => p.Id == Reserva.PacoteTuristicoId);

            Dias = Reserva.DataFinal - pacote.DataInicio;
            valorTotal = calcularValorTotal(Dias.Days, pacote.PrecoDiaria);

            Mensagem = $"Preço da diária do pacote: {pacote.PrecoDiaria}  - Valor Total: {valorTotal}";
            return Page();
        }

        public decimal CalcularValorTotal(int dias, decimal precoDiaria)
        {
            return dias * precoDiaria;
        }

        public void Options()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente.Where(c => c.Deleted == null), "Id", "Nome");
            ViewData["PacoteTuristicoId"] = new SelectList(_context.PacoteTuristico, "Id", "Titulo");
        }

    }
}
