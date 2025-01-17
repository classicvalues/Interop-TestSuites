namespace Microsoft.Protocols.TestSuites.MS_OXORULE
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Protocols.TestSuites.Common;

    /// <summary>
    /// Action Data buffer format for ActionType: OP_MOVE, OP_COPY
    /// </summary>
    public class MoveCopyActionData : IActionData
    {
        /// <summary>
        /// MUST be either 0x01 if the folder whose entry ID is FolderEID is in the server store, or 0x00 if the folder is in a different store (for example, a local store the server cannot access).
        /// </summary>
        private byte folderInThisStore;

        /// <summary>
        /// The Size of the StoreEID BYTE array.
        /// </summary>
        private ushort storeEIDSize;

        /// <summary>
        /// The binary buffer specifies the destination store EntryID. StoreEID is specified in [MS-OXCDATA] section 2.2.4.3.
        /// </summary>
        private byte[] storeEID;

        /// <summary>
        /// The Size of the FolderEID BYTE array
        /// </summary>
        private ushort folderEIDSize;

        /// <summary>
        /// The binary buffer specifies the destination folder's EntryID. If the value of FolderInThisStore is 0x01, then the structure of this field is specified in [MS-OXCDATA] section 2.2.4.1.
        /// </summary>
        private byte[] folderEID;

        /// <summary>
        /// Gets or sets the FolderInThisStore
        /// </summary>
        public byte FolderInThisStore
        {
            get { return this.folderInThisStore; }
            set { this.folderInThisStore = value; }
        }

        /// <summary>
        /// Gets or sets the Size of the StoreEID BYTE array.
        /// </summary>
        public ushort StoreEIDSize
        {
            get { return this.storeEIDSize; }
            set { this.storeEIDSize = value; }
        }

        /// <summary>
        /// Gets or sets the binary buffer specifies the destination store EntryID. StoreEID is specified in [MS-OXCDATA] section 2.2.4.3.
        /// </summary>
        public byte[] StoreEID
        {
            get { return this.storeEID; }
            set { this.storeEID = value; }
        }

        /// <summary>
        /// Gets or sets the Size of the FolderEID BYTE array
        /// </summary>
        public ushort FolderEIDSize
        {
            get { return this.folderEIDSize; }
            set { this.folderEIDSize = value; }
        }

        /// <summary>
        /// Gets or sets the FolderEID
        /// </summary>
        public byte[] FolderEID
        {
            get { return this.folderEID; }
            set { this.folderEID = value; }
        }

        /// <summary>
        /// The total Size of this ActionData buffer
        /// </summary>
        /// <returns>Number of bytes in this ActionData buffer.</returns>
        public int Size()
        {
            return this.Serialize().Length;
        }

        /// <summary>
        /// Get serialized byte array for this ActionData
        /// </summary>
        /// <returns>Serialized byte array.</returns>
        public byte[] Serialize()
        {
            List<byte> result = new List<byte>
            {
                this.FolderInThisStore
            };
            result.AddRange(BitConverter.GetBytes(this.StoreEIDSize));
            if (this.StoreEIDSize != 0)
            {
                result.AddRange(this.StoreEID);
            }
            
            result.AddRange(BitConverter.GetBytes(this.FolderEIDSize));
            result.AddRange(this.FolderEID);

            return result.ToArray();
        }

        /// <summary>
        /// Deserialized byte array to a MoveCopyActionData instance
        /// </summary>
        /// <param name="buffer">Byte array contains data of an ActionData instance.</param>
        /// <returns>Bytes count that deserialized in buffer.</returns>
        public uint Deserialize(byte[] buffer)
        {
            BufferReader bufferReader = new BufferReader(buffer);
            this.FolderInThisStore = bufferReader.ReadByte();
            this.StoreEIDSize = bufferReader.ReadUInt16();
            this.StoreEID = bufferReader.ReadBytes(this.StoreEIDSize);
            this.FolderEIDSize = bufferReader.ReadUInt16();
            this.FolderEID = bufferReader.ReadBytes(this.FolderEIDSize);

            return bufferReader.Position;
        }
    }
}