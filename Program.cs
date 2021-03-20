using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CancelAsync.CompilerServices;
using System;
using System.Runtime.CompilerServices;

namespace CancelAsync
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class CancelableAsync
    {
        [Params(5, 10, 20)]
        public int Recursion;

        [Benchmark]
        public void ThrowCancelation()
        {
            Execute(Recursion);
        }

        [Benchmark(Baseline = true)]
        public void DirectCancelation()
        {
            ExecuteDirect(Recursion);
        }

        //private async CustomTask ExecuteDirect(int repeats)
        //{
        //    if (repeats == 0)
        //    {
        //        await new CustomTask(true); // IsCanceled returns true to cancel the async function directly.
        //    }
        //    await ExecuteDirect(--repeats);
        //}
        private struct _d__1 : IAsyncStateMachine
        {
            public int _1__state;

            public CustomTaskMethodBuilder _t__builder;

            public int repeats;

            public CancelableAsync _4__this;

            private CustomTask _u__1;

            private void MoveNext()
            {
                int num = _1__state;
                CancelableAsync cancelableAsync = _4__this;
                try
                {
                    CustomTask awaiter;
                    if (num != 0)
                    {
                        if (num == 1)
                        {
                            awaiter = _u__1;
                            _u__1 = default(CustomTask);
                            num = (_1__state = -1);
                            goto IL_00e2;
                        }
                        if (repeats != 0)
                        {
                            goto IL_0080;
                        }
                        awaiter = new CustomTask(true).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = (_1__state = 0);
                            _u__1 = awaiter;
                            _t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = _u__1;
                        _u__1 = default(CustomTask);
                        num = (_1__state = -1);
                    }
                    awaiter.GetResult();
                    goto IL_0080;
                    IL_00e2:
                    awaiter.GetResult();
                    goto end_IL_000e;
                    IL_0080:
                    awaiter = cancelableAsync.Execute(--repeats).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (_1__state = 1);
                        _u__1 = awaiter;
                        _t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                        return;
                    }
                    goto IL_00e2;
                    end_IL_000e:;
                }
                catch (Exception exception)
                {
                    _1__state = -2;
                    _t__builder.SetException(exception);
                    return;
                }
                _1__state = -2;
                _t__builder.SetResult();
            }

            void IAsyncStateMachine.MoveNext()
            {
                this.MoveNext();
            }

            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                _t__builder.SetStateMachine(stateMachine);
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.SetStateMachine(stateMachine);
            }
        }

        private CustomTask Execute(int repeats)
        {
            _d__1 stateMachine = default(_d__1);
            stateMachine._t__builder = CustomTaskMethodBuilder.Create();
            stateMachine._4__this = this;
            stateMachine.repeats = repeats;
            stateMachine._1__state = -1;
            stateMachine._t__builder.Start(ref stateMachine);
            return stateMachine._t__builder.Task;
        }



        private struct _d__2 : IAsyncStateMachine
        {
            public int _1__state;

            public CustomTaskMethodBuilder _t__builder;

            public int repeats;

            public CancelableAsync _4__this;

            private CustomTask _u__1;

            private void MoveNext()
            {
                int num = _1__state;
                CancelableAsync cancelableAsync = _4__this;
                try
                {
                    CustomTask awaiter;
                    if (num != 0)
                    {
                        if (num == 1)
                        {
                            awaiter = _u__1;
                            _u__1 = default(CustomTask);
                            num = (_1__state = -1);
                            goto IL_00dc;
                        }
                        if (repeats != 0)
                        {
                            goto IL_007a;
                        }
                        awaiter = new CustomTask(true).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = (_1__state = 0);
                            _u__1 = awaiter;
                            _t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = _u__1;
                        _u__1 = default(CustomTask);
                        num = (_1__state = -1);
                    }
                    if (awaiter.IsCanceled)
                    {
                        _1__state = -2;
                        _t__builder.SetCancelation(awaiter);
                        return;
                    }
                    awaiter.GetResult();
                    goto IL_007a;
                    IL_00dc:
                    if (awaiter.IsCanceled)
                    {
                        _1__state = -2;
                        _t__builder.SetCancelation(awaiter);
                        return;
                    }
                    awaiter.GetResult();
                    goto end_IL_000e;
                    IL_007a:
                    awaiter = cancelableAsync.ExecuteDirect(--repeats).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (_1__state = 1);
                        _u__1 = awaiter;
                        _t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                        return;
                    }
                    goto IL_00dc;
                    end_IL_000e:;
                }
                catch (Exception exception)
                {
                    _1__state = -2;
                    _t__builder.SetException(exception);
                    return;
                }
                _1__state = -2;
                _t__builder.SetResult();
            }

            void IAsyncStateMachine.MoveNext()
            {
                this.MoveNext();
            }

            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                _t__builder.SetStateMachine(stateMachine);
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.SetStateMachine(stateMachine);
            }
        }

        private CustomTask ExecuteDirect(int repeats)
        {
            _d__2 stateMachine = default(_d__2);
            stateMachine._t__builder = CustomTaskMethodBuilder.Create();
            stateMachine._4__this = this;
            stateMachine.repeats = repeats;
            stateMachine._1__state = -1;
            stateMachine._t__builder.Start(ref stateMachine);
            return stateMachine._t__builder.Task;
        }
    }
}
