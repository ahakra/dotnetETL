using ServiceMesh.Entities;
using AutoMapper;
using ServiceMesh;
using Google.Protobuf.WellKnownTypes;
namespace ServiceMesh;

public class MappingRule : Profile{
    public  MappingRule()
    {
     
        CreateMap<DateTime, Timestamp>().ConvertUsing(dt => Timestamp.FromDateTime(DateTime.SpecifyKind(dt, DateTimeKind.Utc)));

      
        CreateMap<ServiceInfoEntity, ServiceInfo>()
            //.ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => Timestamp.FromDateTime(DateTime.SpecifyKind(src.Timestamp, DateTimeKind.Utc))))
            .ForMember(dest => dest.Adapters, opt => opt.MapFrom(src => src.Adapters))
            .ReverseMap();

        CreateMap<ServiceInfo, ServiceInfoEntity>()
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp.ToDateTime()));


        
        CreateMap<ServiceAdapterEntity, ServiceAdapter>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ServiceInfoId, opt => opt.MapFrom(src => src.ServiceInfoEntityId))
            .ForMember(dest => dest.ProtocolUsed, opt => opt.MapFrom(src => MapToProtocolUsed(src.ProtocolUsed)))
            .ForMember(dest => dest.ProtocolDescription, opt => opt.MapFrom(src => src.ProtocolDescription))
            .ReverseMap();



    }

   
    private ProtocolUsed MapToProtocolUsed(ProtocolUsedEnum protocolUsedEnum)
    {
        // Implement the logic to map from ProtocolUsedEnum to ProtocolUsed
        switch (protocolUsedEnum)
        {
            case ProtocolUsedEnum.HTTP:
                return ProtocolUsed.WebApi;
            case ProtocolUsedEnum.gRPC:
                return ProtocolUsed.Grpc;
            case ProtocolUsedEnum.Kafka:
                return ProtocolUsed.Kafka;
            default:
                throw new ArgumentOutOfRangeException(nameof(protocolUsedEnum), protocolUsedEnum, "Unsupported ProtocolUsedEnum value.");
        }
    }
 }
