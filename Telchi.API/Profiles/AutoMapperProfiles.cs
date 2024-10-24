using AutoMapper;
using Telchi.Dto.Request.SAP;
using Telchi.Entities.SAP;

namespace Telchi.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        #region Constructores
        public AutoMapperProfiles()
        {
            CreateMap<DtoSAPRequestQuotation, SAPQuotation>()
                .ForMember(ent => ent.DocDate, dto => dto.MapFrom(x => x.DocDate))
                .ForMember(ent => ent.DocDueDate, dto => dto.MapFrom(x => x.DocDueDate))
                .ForMember(ent => ent.CardCode, dto => dto.MapFrom(x => x.CardCode))
                .ForMember(ent => ent.DocTotal, dto => dto.MapFrom(x => x.DocTotal))
                .ForMember(ent => ent.Comments, dto => dto.MapFrom(x => x.Comments))
                .ForMember(ent => ent.TaxDate, dto => dto.MapFrom(x => x.TaxDate))
                .ForMember(ent => ent.Usuario, dto => dto.MapFrom(x => x.Usuario))
                .ForMember(ent => ent.CodigoDeAsegurado, dto => dto.MapFrom(x => x.CodigoDeAsegurado))
                .ForMember(ent => ent.NombreDeAsegurado, dto => dto.MapFrom(x => x.NombreDeAsegurado))
                .ForMember(ent => ent.Poliza, dto => dto.MapFrom(x => x.Poliza))
                .ForMember(ent => ent.Certificado, dto => dto.MapFrom(x => x.Certificado))
                .ForMember(ent => ent.CodigoDeTarjeta, dto => dto.MapFrom(x => x.CodigoDeTarjeta))
                .ForMember(ent => ent.CodigoDeMedico, dto => dto.MapFrom(x => x.CodigoDeMedico))
                .ForMember(ent => ent.NombreDeMedico, dto => dto.MapFrom(x => x.NombreDeMedico))
                .ForMember(ent => ent.CodigoDePatologia, dto => dto.MapFrom(x => x.CodigoDePatologia))
                .ForMember(ent => ent.NombreDePatologia, dto => dto.MapFrom(x => x.NombreDePatologia))
                .ForMember(ent => ent.Oficina, dto => dto.MapFrom(x => x.Oficina))
                .ForMember(ent => ent.PorcentajeDeCobertura, dto => dto.MapFrom(x => x.PorcentajeDeCobertura))
                .ForMember(ent => ent.NumeroDeOrden, dto => dto.MapFrom(x => x.NumeroDeOrden))
                .ForMember(ent => ent.AutorizadoPor, dto => dto.MapFrom(x => x.AutorizadoPor))
                .ForMember(ent => ent.Adjunto, dto => dto.MapFrom(x => x.Adjunto))
                .ForMember(ent => ent.DocumentLines, dto => dto.MapFrom(x => x.DocumentLines));

            CreateMap<DtoSAPRequestQuotationLine, SAPQuotationLine>()
                .ForMember(ent => ent.ItemCode, dto => dto.MapFrom(x => x.ItemCode))
                .ForMember(ent => ent.ItemDescription, dto => dto.MapFrom(x => x.ItemDescription))
                .ForMember(ent => ent.Quantity, dto => dto.MapFrom(x => x.Quantity))
                .ForMember(ent => ent.WarehouseCode, dto => dto.MapFrom(x => x.WarehouseCode))
                .ForMember(ent => ent.PriceAfterVAT, dto => dto.MapFrom(x => x.PriceAfterVAT))
                .ForMember(ent => ent.TaxCode, dto => dto.MapFrom(x => x.TaxCode))
                .ForMember(ent => ent.PorcentajeDeCobertura, dto => dto.MapFrom(x => x.PorcentajeDeCobertura));

            CreateMap<DtoSAPRequestInvoice, SAPInvoice>()
                .ForMember(ent => ent.DocEntry, dto => dto.MapFrom(x => x.DocEntry))
                .ForMember(ent => ent.Creada, dto => dto.MapFrom(x => x.Creada))
                .ForMember(ent => ent.Sincronizada, dto => dto.MapFrom(x => x.Sincronizada))
                .ForMember(ent => ent.DocumentLines, dto => dto.MapFrom(x => x.DocumentLines));

            CreateMap<DtoSAPRequestInvoiceLine, SAPInvoiceLine>()
                .ForMember(ent => ent.LineNum, dto => dto.MapFrom(x => x.LineNum))
                .ForMember(ent => ent.Creada, dto => dto.MapFrom(x => x.Creada));
        }
        #endregion
    }
}