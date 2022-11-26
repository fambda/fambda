using static Fambda.F;

namespace Fambda
{
    /// <summary>
    /// Either functional extensions.
    /// </summary>
    public static class EitherExt
    {
        /// <summary>
        /// Maps <see cref="Either{T,R}"/> into <see cref="Either{L,RRes}"/>
        /// </summary>
        public static Either<L, RRes> Map<L, R, RRes>(this Either<L, R> self, Func<R, RRes> func)
            => self.Match<Either<L, RRes>>(
                      Left: (left) => Left(left),
                      Right: (right) => Right(func(right))
                    );

        /// <summary>
        /// Binds <see cref="Either{T,R}"/> into <see cref="Either{L,RRes}"/>
        /// </summary>
        public static Either<L, RRes> Bind<L, R, RRes>(this Either<L, R> self, Func<R, Either<L, RRes>> func)
            => self.Match<Either<L, RRes>>(
                      Left: (left) => Left(left),
                      Right: (right) => func(right)
                    );
    }
}
