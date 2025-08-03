using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.VisualBasic;
using System.Linq;

namespace Book_Store.Services
{
    public class AutherServices : IAutherServices

    {
        private readonly IAutherRepostory _autherRepostory;

        public AutherServices(IAutherRepostory autherRepostory)
        {
            _autherRepostory = autherRepostory;
        }

        public async Task<IEnumerable<Auther>> GetAuther()
        {
           var GetAuther= await _autherRepostory.GetAuther();
            try {
                return  GetAuther.ToList(); 
            }
            catch(Exception ex) {
                return (IEnumerable<Auther>)($"Error: {ex.Message}").ToList();
            }
        }
        public Task<Auther> GetAutherByID(int id)
        {
            try
            {
                var getAuther =  _autherRepostory.GetAutherByID(id);
            
                return getAuther ;
            }
            catch (Exception ex) {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
        public Task<Auther> GetAutherByName(string name)
        {
            var getauther=_autherRepostory.GetAutherByName(name);
            try
            {
                return getauther;
            }
            catch (Exception ex) {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
        public async Task<Auther> CreateAuther(Auther auther)
        {
            throw new NotImplementedException();

        }

        public Task<Auther> DeleteAuther(Auther auther)
        {
            throw new NotImplementedException();
        }

       

      

       

        public Task<IEnumerable<Auther>> GetAutherِAndBook()
        {
            throw new NotImplementedException();
        }

        public object numberbookfromauther(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Auther> UpdateAuther(Auther auther)
        {
            throw new NotImplementedException();
        }
    }
}
