# keda-scaling-job
Keda scaling job with Redis stream

# Deployment
All resources must be public (docker image, redis) cause I don't know how config local machine connection for minikube.
1. Build image and push to docker hub
2. Create job
3. Run KedaScalingJob.Worker
# Knowledge
- maxReplicaCount: max replica of jobs, NOT of pods
    ![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/49a49208-04dd-4e55-b003-073be3772875/Untitled.png)
- parallelism: number of running pods??
- completions: number of completed pod to finish a job.
- 
# TODO
- roollout & scalingStrategy
```
  rollout:
    strategy: gradual                         # Optional. Default: default. Which Rollout Strategy KEDA will use.
    propagationPolicy: foreground             # Optional. Default: background. Kubernetes propagation policy for cleaning up existing jobs during rollout.
  scalingStrategy:
    strategy: "custom"                        # Optional. Default: default. Which Scaling Strategy to use. 
    customScalingQueueLengthDeduction: 1      # Optional. A parameter to optimize custom ScalingStrategy.
    customScalingRunningJobPercentage: "0.5"  # Optional. A parameter to optimize custom ScalingStrategy.
    pendingPodConditions:                     # Optional. A parameter to calculate pending job count per the specified pod conditions
      - "Ready"
      - "PodScheduled"
      - "AnyOtherCustomPodCondition"
    multipleScalersCalculation : "max" # 
```