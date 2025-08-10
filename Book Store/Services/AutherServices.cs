
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

        public async Task<List<AutherModel>> GetAuther()
        {
          
            try {
                var GetAuther = await _autherRepostory.GetAuther();
                if (GetAuther == null) {
                    throw new ApplicationException($"Error: {"The Auther Not Found"}");
                }
                return  GetAuther.ToList(); 
            }
            catch(Exception ex) {
                throw new ApplicationException($" {ex.Message}");
            }
        }
        public async Task<Auther> GetAutherByID(int id)
        {
            try
            {
                var getAuther =await _autherRepostory.GetAutherByID(id);
                if(getAuther==null)
                {
                    throw new ApplicationException($"Error: {"The Auther Not Found"}");
                }
           
                return getAuther;
            }
            catch (Exception ex) {
                throw new ApplicationException($" {ex.Message}");
            }
        }
        public async Task<List<GetAutherModel>> GetAutherِAndBook()
        {
            try
            {
                var getAuther =await _autherRepostory.GetAutherِAndBook();
                if (getAuther == null)
                {
                    throw new ApplicationException($"Error: {"The Auther Not Found"}");
                }
                return (getAuther);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
        }
        public async Task<GetAutherModel> GetAutherByName(string name)
        {
           
            try
            {
                var getauther =await _autherRepostory.GetAutherByName(name);
                if (getauther == null)
                {
                    throw new ApplicationException($"Error: {"The Auther Not Found"}");
                   

                }
                return getauther;
            }
            catch (Exception ex) {
                throw new ApplicationException($" {ex.Message}");
            }

        }
        public async Task<NumberBook> numberbookfromauther(int id)
        {
            try
            {
                
                var get= await _autherRepostory.numberbookfromauther(id);
                if (get == null)
                {
                    throw new ApplicationException($"Error: {"The Auther Not Found"}");
                }
                return get;
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
                if (delete == null)
                {
                    throw new ApplicationException($"Error: {"The Auther Not Found"}");
                }
                delete.IsDeleted = true;
                delete.DeletedTime = DateTime.Now;
               await _autherRepostory.DeleteAuther(delete);
                return (delete);

            }
            catch (Exception ex)
            {
               throw new ApplicationException($" {ex.Message}");
            }
        }


        public async Task<Auther> UpdateAuther(int id, AutherModel auther)
        {
            try
            {

                var update = await _autherRepostory.GetAutherByID(id);
                if (update == null)
                {
                    throw new ApplicationException($" {"The Auther Not Found"}");
                }

                update.FName = auther.FName;
                update.LName = auther.LName;
                update.Country = auther.Country;
                update.BirthDay = auther.BirthDay;



                await _autherRepostory.UpdateAuther(update);

                return (update);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
    }
}
