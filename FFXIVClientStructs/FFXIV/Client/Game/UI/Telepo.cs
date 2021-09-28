﻿using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.STD;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI {
    // Client::Game::UI::Telepo

    // size = 0x58
    // ctor E8 ? ? ? ? 89 B3 ? ? ? ? 48 8D 8B ? ? ? ? 48 8D 05
    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public unsafe partial struct Telepo {
        [FieldOffset(0x00)] public void* vtbl;
        [FieldOffset(0x10)] public StdVector<TeleportInfo> TeleportList;
        [FieldOffset(0x28)] public SelectUseTicketInvoker UseTicketInvoker;

        [StaticAddress("48 8D 0D ?? ?? ?? ?? 48 8B 12")]
        public static partial Telepo* Instance();

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4B 10 84 C0 48 8B 01 74 2C")]
        public partial bool Teleport(uint aetheryteID, byte subIndex);

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 48 08 48 2B 08")]
        public partial void* UpdateAetheryteList();
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public struct TeleportInfo {
        [FieldOffset(0x00)] public uint AetheryteId;
        [FieldOffset(0x04)] public uint GilCost;
        [FieldOffset(0x08)] public ushort TerritoryId;
        [FieldOffset(0x0B)] public byte Ward;
        [FieldOffset(0x0C)] public byte Plot;
        [FieldOffset(0x0D)] public byte SubIndex;
        [FieldOffset(0x0E)] public byte IsFavourite;

        public bool IsSharedHouse => Ward > 0 && Plot > 0;
        public bool IsAppartment => SubIndex == 128 && !IsSharedHouse;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe partial struct SelectUseTicketInvoker {
        [FieldOffset(0x00)] public void* vtbl;
        [FieldOffset(0x10)] public Telepo* Telepo;

        [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 1B 44 0F B6 CE")]
        public partial bool TeleportWithTickets(uint aetheryteID, byte subIndex);
    }
}