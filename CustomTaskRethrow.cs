using CancelAsync.CompilerServices;
using System;
using System.Runtime.CompilerServices;

namespace CancelAsync
{
    [AsyncMethodBuilder(typeof(AsyncCustomTaskRethrowMethodBuilder))]
    public struct CustomTaskRethrow : ICriticalNotifyCompletion
    {
        private OperationCanceledException _canceledException;

        public CustomTaskRethrow(OperationCanceledException canceledException)
        {
            _canceledException = canceledException;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CustomTaskRethrow GetAwaiter()
        {
            return this;
        }

        public bool IsCompleted
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return true;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetResult()
        {
            if (_canceledException != null)
            {
                throw _canceledException;
            }
        }

        public void OnCompleted(Action continuation)
        {
            throw new InvalidOperationException();
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            throw new InvalidOperationException();
        }
    }
}
