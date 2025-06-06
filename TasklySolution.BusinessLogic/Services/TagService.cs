﻿using AutoMapper;
using BusinessLogic.Contracts;
using BusinessLogic.DTOs.Tag;
using DataAccess.Contracts;
using DataAccess.EntityModels;

namespace BusinessLogic.Services
{
    public class TagService : ITagService
    {
        private readonly IRepository<TagEntity> _tagRepository;
        private readonly IMapper _mapper;

        public TagService(IRepository<TagEntity> repository
            , IMapper mapper)
        {
            _tagRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<TagDTO>?> GetTags()
        {
            var result = await _tagRepository.Get();
            return _mapper.Map<List<TagDTO>>(result);
        }

        public async Task<List<TagDTO>?> GetTags(string userId)
        {
            if (userId is null)
                return null;

            var result = await _tagRepository.Get(
                filter: t => t.isGlobal || t.UserId == userId
                );
            return _mapper.Map<List<TagDTO>>(result);
        }

        public async Task<TagDTO?> GetById(Guid id)
        {
            var tag = await _tagRepository.GetById(id);
            return _mapper.Map<TagDTO>(tag);
        }

        public async Task AddGlobalTag(TagAddDTO tag)
        {
            var tagEntity = _mapper.Map<TagEntity>(tag);
            tagEntity.isGlobal = true;
            await _tagRepository.Add(tagEntity);
            await _tagRepository.SaveAsync();
        }

        public async Task AddPersonalityTag(TagAddDTO tag, string userId)
        {
            var tagEntity = _mapper.Map<TagEntity>(tag);
            tagEntity.isGlobal = false;
            tagEntity.UserId = userId;
            await _tagRepository.Add(tagEntity);
            await _tagRepository.SaveAsync();
        }

        public async Task UpdateTag(TagUpdateDTO tag)
        {
            var tagEntity = _mapper.Map<TagEntity>(tag);
            await _tagRepository.Update(tagEntity);
            await _tagRepository.SaveAsync();
        }

        public async Task DeleteTag(Guid Id)
        {
            await _tagRepository.Delete(Id);
        }

    }
}
