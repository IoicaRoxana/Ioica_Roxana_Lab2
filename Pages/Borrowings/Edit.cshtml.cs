﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ioica_Roxana_Lab2.Data;
using Ioica_Roxana_Lab2.Models;

namespace Ioica_Roxana_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Ioica_Roxana_Lab2.Data.Ioica_Roxana_Lab2Context _context;

        public EditModel(Ioica_Roxana_Lab2.Data.Ioica_Roxana_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing =  await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            Borrowing = borrowing;
           ViewData["BookID"] = new SelectList(_context.Book, "ID", "ID");
           ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
          return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
