using System;

namespace DeveloperSample.ClassRefactoring
{
    public abstract class Swallow
    {
        public abstract SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public abstract double GetAirspeedVelocity();
    }

    public class AfricanSwallow : Swallow
    {
        public override SwallowType Type => SwallowType.African;

        public override double GetAirspeedVelocity()
        {
            if (Load == SwallowLoad.None)
            {
                return 22;
            }
            if (Load == SwallowLoad.Coconut)
            {
                return 18;
            }
            throw new InvalidOperationException();
        }
    }

    public class EuropeanSwallow : Swallow
    {
        public override SwallowType Type => SwallowType.European;

        public override double GetAirspeedVelocity()
        {
            if (Load == SwallowLoad.None)
            {
                return 20;
            }
            if (Load == SwallowLoad.Coconut)
            {
                return 16;
            }
            throw new InvalidOperationException();
        }
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType)
        {
            switch (swallowType)
            {
                case SwallowType.African:
                    return new AfricanSwallow();
                case SwallowType.European:
                    return new EuropeanSwallow();
                default:
                    throw new ArgumentException("Invalid swallow type", nameof(swallowType));
            }
        }
    }
}