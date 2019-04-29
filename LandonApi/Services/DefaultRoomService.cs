using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LandonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LandonApi.Services
{
    public class DefaultRoomService : IRoomService
    {
        private readonly HotelApiDbContext _context;
        private readonly IConfigurationProvider _configurationProvider;

        public DefaultRoomService(HotelApiDbContext context, IConfigurationProvider configurationProvider)
        {
            _context = context;
            _configurationProvider = configurationProvider;
        }

        public async Task<Room> GetRoomAsync(Guid id)
        {
            var entity = await _context.Rooms.SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;

            var mapper = _configurationProvider.CreateMapper();
            return mapper.Map<Room>(entity);
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            var query =  _context.Rooms.ProjectTo<Room>(_configurationProvider);
            return await query.ToArrayAsync();
        }
    }
}
