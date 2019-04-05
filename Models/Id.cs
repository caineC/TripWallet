using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripWallet.Models
{
    public class Id : IEquatable<Id>, IEquatable<int[]>
    {

        /// <summary>
        /// Id to [0,0] reference.
        /// </summary>
        public static readonly Id NullId = Id.CreateId(0, 0);

        private readonly int[] refno = new int[2];

        private Id(string id)
        {
            if (id.StartsWith("="))
                id = id.Remove(0, 1);

            string[] parts = id.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                throw new UnsupportedIdException();

            try
            {
                refno[0] = int.Parse(parts[0]);
                refno[1] = int.Parse(parts[1]);
            }
            catch (Exception)
            {
                throw new UnsupportedIdException();
            }
        }

        private Id(int[] refno)
        {
            if (refno.Length != 2)
                throw new UnsupportedIdException();

            this.refno[0] = refno[0];
            this.refno[1] = refno[1];
        }

        public static Id CreateId(string StringId)
        {
            return new Id(StringId);
        }

        public static Id CreateId(int[] RefNo)
        {
            return new Id(RefNo);
        }

        public static Id CreateId(int RefNo1, int RefNo2)
        {
            return new Id(new int[] { RefNo1, RefNo2 });
        }

        public bool IsNullId()
        {
            return (this.refno[0] | this.refno[1]) == 0;
        }

        public override bool Equals(object obj)
        {
            Id otherId = obj as Id;
            return Equals(otherId);
        }

        public bool Equals(Id otherId)
        {
            if (otherId == null)
                return false;

            return this.refno[0] == otherId.refno[0] && this.refno[1] == otherId.refno[1];
        }

        public bool Equals(int[] otherRefNo)
        {
            if (otherRefNo == null || otherRefNo.Length != 2)
                return false;

            return this.refno[0] == otherRefNo[0] && this.refno[1] == otherRefNo[1];
        }

        public override int GetHashCode()
        {
            Debug.Assert(refno != null, "Illegal form of Id class.");
            Debug.Assert(refno.Length == 2, "Illegal form of Id class.");
            return this.refno[0] + this.refno[1];
        }

        public static bool operator ==(Id a, Id b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Id a, Id b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return "=" + refno[0] + "/" + refno[1];
        }

        public int[] ToInt()
        {
            return refno;
        }

        public class UnsupportedIdException : ApplicationException
        {
        }

    }
}
