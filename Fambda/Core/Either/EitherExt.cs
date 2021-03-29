using System;
using static Fambda.F;

namespace Fambda
{
    public static class EitherExt
    {
        public static Either<L, RRes> Map<L, R, RRes>(this Either<L, R> either, Func<R, RRes> func)
            => either.Match<Either<L, RRes>>(
                        Left: (left) => Left(left),
                        Right: (right) => Right(func(right))
                      );
    }
}
