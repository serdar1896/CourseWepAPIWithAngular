using GulaylarCase.Business.Abstract;
using GulaylarCase.Core.Abstract;
using GulaylarCase.Data.Enum;
using GulaylarCase.Data.Models;
using GulaylarCase.Data.ViewModel;
using System;
using System.Linq;

namespace GulaylarCase.Business.Concrete
{
    public class RoleService : IRoleService
    {
        private IRepository<Role> _repository;
        public RoleService(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public ServiceResponse<RoleDto> Delete(int id)
        {
            var response = new ServiceResponse<RoleDto>();
            try
            {
                var query = _repository.GetById(id);
                if (query != null)
                {
                    _repository.Delete(query);
                    response.IsSuccessful = true;
                }
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }

        public ServiceResponse<RoleDto> GetById(int id)
        {
            var response = new ServiceResponse<RoleDto>();
            try
            {
                var item = _repository.GetById(id);
                response.Entity.Id = item.Id;
                response.Entity.Name = item.Name;

                response.IsSuccessful = true;
                if (response.Entity == null)
                {
                    response.IsSuccessful = false;
                    response.ExceptionMessage = ErrorCodes.KayitYok.Text;
                }
            }
            catch (Exception)
            {
                response.IsSuccessful = false;
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
            }
            return response;
        }

        public ServiceResponse<RoleDto> GetList()
        {
            var response = new ServiceResponse<RoleDto>();
            try
            {
                response.List = _repository.TableNoTracking.Select(m => new RoleDto
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToList();
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }

        public ServiceResponse<RoleDto> Insert(RoleDto modelDto)
        {
            var response = new ServiceResponse<RoleDto>();
            try
            {
                var model = new Role();
                model.Id = modelDto.Id;
                model.Name = modelDto.Name;

                _repository.Insert(model);
                response.IsSuccessful = true;
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }

        public ServiceResponse<RoleDto> Update(RoleDto modelDto)
        {
            var response = new ServiceResponse<RoleDto>();
            try
            {
                var model = new Role();
                model.Id = modelDto.Id;
                model.Name = modelDto.Name;

                _repository.Update(model);
                response.IsSuccessful = true;
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }
    }
}
