using System.Collections.Generic;
using TheTankGame.Entities.Parts.Contracts;

namespace TheTankGame.Entities.Miscellaneous.Contracts
{
    public interface IAssembler
    {
        IReadOnlyCollection<IAttackModifyingPart> ArsenalParts { get; }

        IReadOnlyCollection<IDefenseModifyingPart> ShellParts { get; }

        IReadOnlyCollection<IHitPointsModifyingPart> EnduranceParts { get; }

        // Returns the summed up weights of all parts in the assembler
        double TotalWeight { get; }

        // Returns the summed up prices of all parts in the assembler
        decimal TotalPrice { get; }

        // Returns the summed up attackModifiers of all arsenal parts in the assembler
        long TotalAttackModification { get; }

        // Returns the summed up defenseModifiers of all shell parts in the assembler
        long TotalDefenseModification { get; }

        // Returns the summed up hitPointsModifiers of all endurance parts in the assembler
        long TotalHitPointModification { get; }

        // Adds an arsenal part to the assembler
        void AddArsenalPart(IPart arsenalPart);

        // Adds a shell part to the assembler
        void AddShellPart(IPart shellPart);

        // Adds an endurance part to the assembler
        void AddEndurancePart(IPart endurancePart);
    }
}