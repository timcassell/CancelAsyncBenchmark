using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace CancelAsync.CompilerServices
{
    internal struct CustomTaskMethodBuilder
    {
        private bool _canceled;

        public CustomTask Task
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new CustomTask(_canceled); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CustomTaskMethodBuilder Create()
        {
            return new CustomTaskMethodBuilder();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetException(Exception exception)
        {
            _canceled = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetCancelation<TAwaiter>(TAwaiter awaiter)
        {
            _canceled = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetResult()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            awaiter.UnsafeOnCompleted(stateMachine.MoveNext);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Start<TStateMachine>(ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine
        {
            stateMachine.MoveNext();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
    }
}
