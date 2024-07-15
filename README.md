# Development Logs

## July 13 - 14 
#### Sync ADO to Github
1. Using SSH to push to github instead of https, https has issues with PAT and credentials
2. Do not use the ADO default checkout step, because it will set the commit as the [New Ref], meaning the Ref will have name with 40 hex code long, Github does not let clients name the Ref 40 hex code long
3. After setting the Github repo as a remote repo to ADO, using this command to sync them to avoid conflicts of previous draft commits
    ```
    git push --all github      
    ```                        

#### Setup SSH 
1. generate SSH credential files on local machine
2. Copy/paster the credential to Github