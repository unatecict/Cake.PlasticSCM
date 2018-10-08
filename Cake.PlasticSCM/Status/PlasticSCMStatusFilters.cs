using System;

namespace Cake.PlasticSCM.Status
{
    [Flags]
    public enum PlasticSCMStatusFilters
    {
        Added = 1,
        CheckOut = 2,
        Changed = 4,
        Copied = 8,
        Replaced = 16,
        Deleted = 32,
        LocalDeleted = 64,
        Moved = 128,
        LocalMoved = 256,
        TextSameExtension = 1024,
        BinaryAnyExtension = 2048,
        Private = 4096,
        Ignored = 8192,
        HiddenChanged = 0x4000,
        ControlledChanged= 0x8000,
        All = 0x10000
    }
}
