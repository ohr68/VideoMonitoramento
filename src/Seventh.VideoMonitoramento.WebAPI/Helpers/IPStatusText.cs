using System.Net.NetworkInformation;

namespace Seventh.VideoMonitoramento.WebAPI.Helpers
{
    public static class IPStatusText
    {
        public static string GetStatusString(IPStatus status)
        {
            switch (status)
            {
                case IPStatus.BadDestination:
                    return "Bad destination";
                case IPStatus.BadHeader:
                    return "Invalid ICMP header";
                case IPStatus.BadOption:
                    return "Invalid ICMP option";
                case IPStatus.BadRoute:
                    return "There is no valid route to destination.";
                case IPStatus.DestinationHostUnreachable:
                    return "Destination host unreachable.";
                case IPStatus.DestinationNetworkUnreachable:
                    return "Destination network unreachable.";
                case IPStatus.DestinationPortUnreachable:
                    return "Destination port unreachable.";
                case IPStatus.DestinationProtocolUnreachable:
                    return "Destination protocol unreachable.";
                case IPStatus.DestinationScopeMismatch:
                    return "Destination scope mismatch.";
                case IPStatus.DestinationUnreachable:
                    return "Destination computer unreachable.";
                case IPStatus.HardwareError:
                    return "Hardware error.";
                case IPStatus.IcmpError:
                    return "ICMP error.";
                case IPStatus.NoResources:
                    return "Insufficient network resources.";
                case IPStatus.PacketTooBig:
                    return "Packet too big.";
                case IPStatus.ParameterProblem:
                    return "Parameter problem";
                case IPStatus.SourceQuench:
                    return "Source quench.";
                case IPStatus.Success:
                    return "Ping succeeded.";
                case IPStatus.TimeExceeded:
                    return "TTL exceeded.";
                case IPStatus.TimedOut:
                    return "Request timed out.";
                case IPStatus.TtlExpired:
                    return "TTL expired.";
                case IPStatus.TtlReassemblyTimeExceeded:
                    return "TTL reassembly time exceeded";
                case IPStatus.Unknown:
                    return "Ping failed for an unknown reason.";
                case IPStatus.UnrecognizedNextHeader:
                    return "Unrecognized next header.";
                default:
                    return "Ping failed.";
            }
        }
    }
}