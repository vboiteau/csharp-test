FROM public.ecr.aws/lambda/dotnet:6
#You can also pull these images from DockerHub amazon/aws-lambda-dotnet:7
  
# Copy function code
COPY publish/* ${LAMBDA_TASK_ROOT}
  
# Set the CMD to your handler (could also be done as a parameter override outside of the Dockerfile)
CMD [ "MyFunction::MyFunction.Function::FunctionHandler" ]
