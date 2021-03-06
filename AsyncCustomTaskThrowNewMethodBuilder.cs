using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace CancelAsync.CompilerServices
{
    internal struct AsyncCustomTaskThrowNewMethodBuilder
    {
        private bool _canceled;

        public CustomTaskThrowNew Task
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new CustomTaskThrowNew(_canceled); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncCustomTaskThrowNewMethodBuilder Create()
        {
            return new AsyncCustomTaskThrowNewMethodBuilder();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetException(Exception exception)
        {
            _canceled = exception is OperationCanceledException;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetCancelation<TAwaiter>(ref TAwaiter awaiter)
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
