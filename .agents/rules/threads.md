---
trigger: always_on
---

# Threads and Asynchrony

## Task Cancellation

Always use the `CancellationToken` pattern for canceling asynchronous operations or long-running tasks.
Avoid useing boolean flags or direct `Task` disposal to stop asynchronous operations. Pass a `CancellationToken` to methods that support it.


