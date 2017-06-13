using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Effects
{
    public class Effect
    {
        public int AffectedRounds { get; set; }

        public Unit From { get; set; }

        public Unit To { get; set; }

        public Effect()
        {

        }

        public Effect(Unit p1, Unit p2)
        {
            From = p1;
            To = p2;
        }

        public virtual BattleRecord initialize(BattleRecord record)
        {
            return record;
        }


        public virtual BattleRecord applyBeforeAttack(BattleRecord record)
        {
            return record;
        }

        public virtual BattleRecord applyAfterAttack(BattleRecord record)
        {
            return record;
        }

        public virtual BattleRecord applyWhenTurnOver(BattleRecord record)
        {
            return record;
        }

        public virtual BattleRecord Apply() { return new BattleRecord(); }

        public virtual bool stopAttach(BattleRecord record) { return false; }


        public bool Expired()
        {
            return AffectedRounds <= 0;
        }

    }
}
