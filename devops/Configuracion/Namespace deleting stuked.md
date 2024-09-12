# Delete namespace stucked

- Get the resources that are not deleted:

```bash
kubectl api-resources --verbs=list --namespaced -o name | xargs -n 1 kubectl get --show-kind --ignore-not-found -n <terminating-namespace>
```

- Go to the resource and edit `metadata.finalizers[]` to empty
