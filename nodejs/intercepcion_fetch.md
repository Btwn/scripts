[Intercepting JavaScript Fetch API requests and responses](https://blog.logrocket.com/intercepting-javascript-fetch-api-requests-responses/)

One way to create an interceptor for any JavaScript function or method is to monkey patch it. Monkey patching is an approach to override the original functionality with your version of the function.

Let’s take a step-by-step look at how you can create an interceptor for the Fetch API with monkey patching:

```javascript
const { fetch: originalFetch } = window;

window.fetch = async (...args) => {
    let [resource, config ] = args;
    // request interceptor here
    const response = await originalFetch(resource, config);
    // response interceptor here
    return response;
};
```
