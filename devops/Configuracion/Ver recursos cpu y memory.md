```bash
kubectl get po -o custom-columns="Name:metadata.name,CPU-limit:spec.containers[*].resources.limits.cpu,CPU-requests:spec.containers[*].resources.requests.cpu,RAM-limit:spec.containers[*].resources.limits.memory,RAM-requests:spec.containers[*].resources.requests.memory" -A
```
