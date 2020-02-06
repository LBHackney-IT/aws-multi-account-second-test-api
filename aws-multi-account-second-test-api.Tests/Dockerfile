FROM microsoft/dotnet:2.2-sdk

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./aws-multi-account-second-test-api.sln ./
COPY ./aws-multi-account-second-test-api/aws-multi-account-second-test-api.csproj ./aws-multi-account-second-test-api/
COPY ./aws-multi-account-second-test-api.Tests/aws-multi-account-second-test-api.Tests.csproj ./aws-multi-account-second-test-api.Tests/

RUN dotnet restore ./aws-multi-account-second-test-api/aws-multi-account-second-test-api.csproj
RUN dotnet restore ./aws-multi-account-second-test-api.Tests/aws-multi-account-second-test-api.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out aws-multi-account-second-test-api.Tests/aws-multi-account-second-test-api.Tests.csproj

CMD dotnet test
