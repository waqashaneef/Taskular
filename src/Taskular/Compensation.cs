// Copyright 2007-2014 Chris Patterson
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance
// with the License. You may obtain a copy of the License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed
// on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and limitations under the License.
namespace Taskular
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;


    public interface Compensation
    {
        CancellationToken CancellationToken { get; }

        /// <summary>
        ///     The exception that triggered the compensation
        /// </summary>
        Exception Exception { get; }


        /// <summary>
        ///     Mark the exception as handled, preventing further compensation
        /// </summary>
        /// <returns></returns>
        CompensationResult Handled();

        /// <summary>
        ///     Return a Task in response to the exception
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        CompensationResult Task(Task task);

        /// <summary>
        ///     Throw the specified exception instead of the exception that caused the compensation
        /// </summary>
        /// <param name="exception">The exception to throw instead of the initial exception</param>
        /// <returns></returns>
        CompensationResult Throw<TException>(TException exception)
            where TException : Exception;

        /// <summary>
        ///     Throw the exception that caused the compensation, continuing the compensation flow
        /// </summary>
        /// <returns></returns>
        CompensationResult Throw();
    }
}