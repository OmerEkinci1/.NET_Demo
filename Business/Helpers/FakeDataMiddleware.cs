using Business.Fakes.Handlers.Languages;
using Business.Fakes.Handlers.Translates;
using Core.Utilities.IoC;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public static class FakeDataMiddleware
    {
        public static async Task UseDbFakeDataCreator(this IApplicationBuilder app)
        {
            var mediator = ServiceTool.ServiceProvider.GetService<IMediator>();

            await mediator.Send(new CreateLanguageInternalCommand { Code = "tr-TR", Name = "Türkçe" });
            await mediator.Send(new CreateLanguageInternalCommand { Code = "en-EN", Name = "English" });

            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Update", Value = "Güncelle" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Delete", Value = "Sil" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Create", Value = "Yeni" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Update", Value = "Update" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Delete", Value = "Delete" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Create", Value = "Create" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Languages", Value = "Diller" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Languages", Value = "Languages" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "TranslateWords", Value = "Dil Çevirileri" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "TranslateWords", Value = "Translate Words" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Added", Value = "Başarıyla Eklendi." });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Added", Value = "Successfully Added." });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Updated", Value = "Başarıyla Güncellendi." });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Updated", Value = "Successfully Updated." });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Deleted", Value = "Başarıyla Silindi." });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Deleted", Value = "Successfully Deleted." });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Unknown", Value = "Bilinmiyor!" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Unknown", Value = "Unknown!" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Save", Value = "Kaydet" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Save", Value = "Save" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Value", Value = "Değer" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Value", Value = "Value" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "LangCode", Value = "Dil Kodu" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "LangCode", Value = "Lang Code" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "Add", Value = "Ekle" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "Add", Value = "Add" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "LanguageList", Value = "Dil Listesi" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "LanguageList", Value = "Language List" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "TranslateList", Value = "Dil Çeviri Listesi" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "TranslateList", Value = "Translate List" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 1, Code = "DeleteConfirm", Value = "Emin misiniz?" });
            await mediator.Send(new CreateTranslateInternalCommand { LangId = 2, Code = "DeleteConfirm", Value = "Are you sure?" });
        } 
    }
}
