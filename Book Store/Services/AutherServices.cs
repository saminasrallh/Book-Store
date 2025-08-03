using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.Model;
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
          
            try {
                var GetAuther = await _autherRepostory.GetAuther();
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
        public Task<IEnumerable<Auther>> GetAutherِAndBook()
        {
            try
            {
                var getAuther = _autherRepostory.GetAutherِAndBook();
                return (getAuther);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
        public Task<Auther> GetAutherByName(string name)
        {
           
            try
            {
                var getauther = _autherRepostory.GetAutherByName(name);
                return getauther;
            }
            catch (Exception ex) {
                throw new ApplicationException($"Error: {ex.Message}");
            }

        }
        public object numberbookfromauther(int id)
        {
            try
            {
                return _autherRepostory.numberbookfromauther(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
        public async Task<Auther> CreateAuther(AutherModel auther)
        {
            try
            {
                var create = new Auther
                {
                    FName = auther.FName,
                    LName = auther.LName,
                    Country = auther.Country,
                    BirthDay = auther.BirthDay,


                };
                await _autherRepostory.CreateAuther(create);
                return (create);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }

            }

        public async Task<Auther> DeleteAuther(int id)
        {
            try
            {
                var delete = await _autherRepostory.GetAutherByID(id);
                _autherRepostory.DeleteAuther(delete);
                return (delete);

            }
            catch (Exception ex)
            {
               throw new ApplicationException($"Error: {ex.Message}");
            }
        }


        public async Task<Auther> UpdateAuther(int id, AutherModel auther)
        {
            try
            {

                var update = await _autherRepostory.GetAutherByID(id);

                update.FName = auther.FName;
                update.LName = auther.LName;
                update.Country = auther.Country;
                update.BirthDay = auther.BirthDay;



                _autherRepostory.UpdateAuther(update);

                return (update);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
    }
}
