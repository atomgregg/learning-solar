1. Install NVM for windows
(https://github.com/coreybutler/nvm-windows/releases)

2. Install the latest LTS nodejs version

first list the available versions, then select the desired LTS version

```bash
PS D:\learning\ATG> nvm list available

|   CURRENT    |     LTS      |  OLD STABLE  | OLD UNSTABLE |
|--------------|--------------|--------------|--------------|
|    20.2.0    |   18.16.0    |   0.12.18    |   0.11.16    |
|    20.1.0    |   18.15.0    |   0.12.17    |   0.11.15    |
|    20.0.0    |   18.14.2    |   0.12.16    |   0.11.14    |
|    19.9.0    |   18.14.1    |   0.12.15    |   0.11.13    |
|    19.8.1    |   18.14.0    |   0.12.14    |   0.11.12    |
|    19.8.0    |   18.13.0    |   0.12.13    |   0.11.11    |
|    19.7.0    |   18.12.1    |   0.12.12    |   0.11.10    |
|    19.6.1    |   18.12.0    |   0.12.11    |    0.11.9    |
|    19.6.0    |   16.20.0    |   0.12.10    |    0.11.8    |
|    19.5.0    |   16.19.1    |    0.12.9    |    0.11.7    |
|    19.4.0    |   16.19.0    |    0.12.8    |    0.11.6    |
|    19.3.0    |   16.18.1    |    0.12.7    |    0.11.5    |
|    19.2.0    |   16.18.0    |    0.12.6    |    0.11.4    |
|    19.1.0    |   16.17.1    |    0.12.5    |    0.11.3    |
|    19.0.1    |   16.17.0    |    0.12.4    |    0.11.2    |
|    19.0.0    |   16.16.0    |    0.12.3    |    0.11.1    |
|   18.11.0    |   16.15.1    |    0.12.2    |    0.11.0    |
|   18.10.0    |   16.15.0    |    0.12.1    |    0.9.12    |

PS D:\learning\ATG> nvm install 18.16.0
Downloading node.js version 18.16.0 (64-bit)...
Extracting node and npm...
Complete
npm v9.5.1 installed successfully.


Installation complete. If you want to use this version, type

nvm use 18.16.0
```

3. Use the desired version of npm

```bash
PS D:\learning\ATG> nvm ls

    18.16.0
PS D:\learning\ATG> nvm use 18.16.0
Now using node v18.16.0 (64-bit)
PS D:\learning\ATG> npm --version
9.5.1
```

4. Install VueJS

```bash
PS D:\learning\ATG> npm install vue

added 20 packages in 6s

2 packages are looking for funding
  run `npm fund` for details
npm notice
npm notice New minor version of npm available! 9.5.1 -> 9.6.7
npm notice Changelog: https://github.com/npm/cli/releases/tag/v9.6.7
npm notice Run npm install -g npm@9.6.7 to update!
npm notice
```

5. Install the CLI and get scared by all the warnings

```bash
PS D:\learning\ATG> npm install -g @vue/cli
npm WARN deprecated source-map-url@0.4.1: See https://github.com/lydell/source-map-url#deprecated
npm WARN deprecated urix@0.1.0: Please see https://github.com/lydell/urix#deprecated
npm WARN deprecated resolve-url@0.2.1: https://github.com/lydell/resolve-url#deprecated
npm WARN deprecated source-map-resolve@0.5.3: See https://github.com/lydell/source-map-resolve#deprecated
npm WARN deprecated apollo-server-plugin-base@3.7.2: The `apollo-server-plugin-base` package is part of Apollo Server v2 and v3, which are now deprecated (end-of-life October 22nd 2023). This package's functionality is now found in the `@apollo/server` package. See https://www.apollographql.com/docs/apollo-server/previous-versions/ for more details.
npm WARN deprecated apollo-datasource@3.3.2: The `apollo-datasource` package is part of Apollo Server v2 and v3, which are now deprecated (end-of-life October 22nd 2023). See https://www.apollographql.com/docs/apollo-server/previous-versions/ for more details.
npm WARN deprecated apollo-server-errors@3.3.1: The `apollo-server-errors` package is part of Apollo Server v2 and v3, which are now deprecated (end-of-life October 22nd 2023). This package's functionality is now found in the `@apollo/server` package. See https://www.apollographql.com/docs/apollo-server/previous-versions/ for more details.
npm WARN deprecated apollo-server-types@3.8.0: The `apollo-server-types` package is part of Apollo Server v2 and v3, which are now deprecated (end-of-life October 22nd 2023). This package's functionality is now found in the `@apollo/server` package. See https://www.apollographql.com/docs/apollo-server/previous-versions/ for more details.
npm WARN deprecated apollo-reporting-protobuf@3.4.0: The `apollo-reporting-protobuf` package is part of Apollo Server v2 and v3, which are now deprecated (end-of-life October 22nd 2023). This package's functionality is now found in the `@apollo/usage-reporting-protobuf` package. See https://www.apollographql.com/docs/apollo-server/previous-versions/ for more details.
npm WARN deprecated apollo-server-env@4.2.1: The `apollo-server-env` package is part of Apollo Server v2 and v3, which are now deprecated (end-of-life October 22nd 2023). This package's functionality is now found in the `@apollo/utils.fetcher` package. See https://www.apollographql.com/docs/apollo-server/previous-versions/ for more details.
npm WARN deprecated subscriptions-transport-ws@0.11.0: The `subscriptions-transport-ws` package is no longer maintained. We recommend you use `graphql-ws` instead. For help migrating Apollo software to `graphql-ws`, see https://www.apollographql.com/docs/apollo-server/data/subscriptions/#switching-from-subscriptions-transport-ws    For general help using `graphql-ws`, see https://github.com/enisdenjo/graphql-ws/blob/master/README.md
npm WARN deprecated apollo-server-express@3.12.0: The `apollo-server-express` package is part of Apollo Server v2 and v3, which are now deprecated (end-of-life October 22nd 2023). This package's functionality is now found in the `@apollo/server` package. See https://www.apollographql.com/docs/apollo-server/previous-versions/ for more details.
npm WARN deprecated apollo-server-core@3.12.0: The `apollo-server-core` package is part of Apollo Server v2 and v3, which are now deprecated (end-of-life October 22nd 2023). This package's functionality is now found in the `@apollo/server` package. See https://www.apollographql.com/docs/apollo-server/previous-versions/ for more details.

added 867 packages in 1m
```

6. Try and fail to create an app.. 

First: not from a Powershell prompt

```bash
PS D:\learning\ATG> vue create ATG.Collector.UI
vue : File C:\Program Files\nodejs\vue.ps1 cannot be loaded because running scripts is disabled on this system. For
more information, see about_Execution_Policies at https:/go.microsoft.com/fwlink/?LinkID=135170.
At line:1 char:1
+ vue create ATG.Collector.UI
+ ~~~
    + CategoryInfo          : SecurityError: (:) [], PSSecurityException
    + FullyQualifiedErrorId : UnauthorizedAccess
```

Second: use a different naming convention
```bash
atomg@aaron-hp MINGW64 /d/learning/ATG (main)
$ vue create atg-collector-ui
?  Your connection to the default npm registry seems to be slow.
   Use https://registry.npmmirror.com for faster installation? No


Vue CLI v5.0.8
? Please pick a preset: Default ([Vue 3] babel, eslint)


Vue CLI v5.0.8
✨  Creating project in D:\learning\ATG\atg-collector-ui.
⚙️  Installing CLI plugins. This might take a while...


added 862 packages, and audited 863 packages in 41s

93 packages are looking for funding
  run `npm fund` for details

found 0 vulnerabilities
🚀  Invoking generators...
📦  Installing additional dependencies...


added 101 packages, and audited 964 packages in 5s

106 packages are looking for funding
  run `npm fund` for details

found 0 vulnerabilities
⚓  Running completion hooks...

📄  Generating README.md...

🎉  Successfully created project atg-collector-ui.
👉  Get started with the following commands:

 $ cd atg-collector-ui
 $ npm run serve
 ```