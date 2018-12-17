namespace TheTankGame.Entities.Miscellaneous
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Parts.Contracts;

    public class VehicleAssembler : IAssembler
    {
        private readonly IList<IAttackModifyingPart> arsenalParts;
        private readonly IList<IDefenseModifyingPart> shellParts;
        private readonly IList<IHitPointsModifyingPart> enduranceParts;

        public VehicleAssembler()
        {
            this.arsenalParts = new List<IAttackModifyingPart>();
            this.shellParts = new List<IDefenseModifyingPart>();
            this.enduranceParts = new List<IHitPointsModifyingPart>();
        }

        public IReadOnlyCollection<IAttackModifyingPart> ArsenalParts
                                => this.arsenalParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IDefenseModifyingPart> ShellParts
                                => this.shellParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IHitPointsModifyingPart> EnduranceParts
                                => this.enduranceParts.ToList().AsReadOnly();

        public double TotalWeight
        {
            get
            {
                return this.ArsenalParts.Sum(p => p.Weight) +
                  this.ShellParts.Sum(p => p.Weight) +
                  this.EnduranceParts.Sum(p => p.Weight);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return this.ArsenalParts.Sum(p => p.Price) +
                    this.ShellParts.Sum(p => p.Price) +
                    this.EnduranceParts.Sum(p => p.Price);
            }
        }

        public long TotalAttackModification
        {
            get
            {
                return this.ArsenalParts.Sum(p => p.AttackModifier);
            }
        }

        public long TotalDefenseModification
        {
            get
            {
                return this.ShellParts.Sum(p => p.DefenseModifier);
            }
        }

        public long TotalHitPointModification
        {
            get
            {
                return this.EnduranceParts.Sum(p => p.HitPointsModifier);
            }
        }

        public void AddArsenalPart(IPart arsenalPart)
        {
            this.arsenalParts.Add((IAttackModifyingPart)arsenalPart);
        }

        public void AddShellPart(IPart shellPart)
        {
            this.shellParts.Add((IDefenseModifyingPart)shellPart);
        }

        public void AddEndurancePart(IPart endurancePart)
        {
            this.enduranceParts.Add((IHitPointsModifyingPart)endurancePart);
        }
    }
}