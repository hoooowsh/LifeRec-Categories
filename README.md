# LifeRec-Categories Intro
This is a micro-service for LifeRec, mainly serve for categories related CRUD Operations
ADO: https://dev.azure.com/LifeRec/LifeRecApp
Github: https://github.com/hoooowsh/LifeRec-Categories

## Tech stack
- C#
- .Net
- MongoDB
- Azure Active Directory
- Docker
- AKS
- Azure Devops

# Costs analysis
### Database
- MongoDB free tier
### AKS
- $7 for a single node


# Development Logs
## July 13 - 14 
#### Setup local runner
- Follow the instruction on ADO, it is very clear
- Useful command lines
    ```
    # Config runner
    ./config.sh
    # run the runner shell
    ./run.sh
    ```

#### Sync ADO to Github
1. Using SSH to push to github instead of https, https has issues with PAT and credentials
2. Do not use the ADO default checkout step, because it will set the commit as the [New Ref], meaning the Ref will have name with 40 hex code long, Github does not let clients name the Ref 40 hex code long
3. After setting the Github repo as a remote repo to ADO, using this command to sync them to avoid conflicts of previous draft commits
    ```
    git push --all github      
    ```                        

#### Setup SSH 
1. generate SSH credential files on local machine
2. Copy/paste the credential to Github

#### MongoDB set up
- Public IP (Ex: Library) cannot connect to MongoDB even MongoDB is open for all IP addresses

## July 15