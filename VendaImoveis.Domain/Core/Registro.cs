﻿namespace VendaImoveis.Domain.Core
{
    public abstract class Registro
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
