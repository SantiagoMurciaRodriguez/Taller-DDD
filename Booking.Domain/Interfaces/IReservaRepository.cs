﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces
{
    public interface IReservaRepository
    {
        Task<Reserva?> GetByIdAsync(Guid id);
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task AddAsync(Reserva reserva);
        Task UpdateAsync(Reserva reserva);
        Task DeleteAsync(Guid id);
    }
}
