using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.BookDtos;
using Application.Features.Book.Commands.Create;
using Application.Features.Book.Commands.Update;
using Application.Features.Book.Queries.GetAll;
using Application.Features.Book.Queries.GetById;
using Application.Features.Category.Commands.Create;
using Application.Features.Category.Commands.Update;
using Application.Features.Category.Queries.GetAll;
using Application.Features.Category.Queries.GetById;
using AutoMapper;
using BookStore.Core.Domain.Entities;
using Domain.Entities;

namespace Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Book
            CreateMap<CreateBookCommandRequest, Book>().ReverseMap();
            CreateMap<UpdateBookCommandRequest, Book>().ReverseMap();
            CreateMap<Book, GetAllBooksQueryResponse>().ReverseMap();
            CreateMap<Book, GetBookByIdQueryResponse>().ReverseMap();
            CreateMap<GetBookDto, GetBookByIdQueryResponse>().ReverseMap();
            
            // Category
            CreateMap<CreateCategoryCommandRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommandRequest, Category>().ReverseMap();
            CreateMap<Category, GetAllCategoriesQueryResponse>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQueryResponse>().ReverseMap();
        }
    }
}