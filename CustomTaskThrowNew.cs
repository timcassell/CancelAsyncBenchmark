using CancelAsync.CompilerServices;
using System;
using System.Runtime.CompilerServices;

namespace CancelAsync
{
    [AsyncMethodBuilder(typeof(AsyncCustomTaskThrowNewMethodBuilder))]
    public struct CustomTaskThrowNew : ICriticalNotifyCompletion
    {
        private bool _canceled;

        public CustomTaskThrowNew(bool canceled)
        {
            _canceled = canceled;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CustomTaskThrowNew GetAwaiter()
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

        public bool IsCanceled
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return _canceled;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetResult()
        {
            if (_canceled)
            {
                throw new OperationCanceledException();
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
