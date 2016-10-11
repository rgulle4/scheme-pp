#!/bin/bash
set -e

SSH_SERVER='cl410137'
SSH_DESTINATION='cl410137:~/prog1/'

ssh $SSH_SERVER rm -rf prog1/
ssh $SSH_SERVER mkdir prog1/

scp -r Parse/ $SSH_DESTINATION 
scp -r Special/ $SSH_DESTINATION 
scp -r Tokens/ $SSH_DESTINATION 
scp -r Tree/ $SSH_DESTINATION 
scp -r Makefile $SSH_DESTINATION 
scp -r README.md $SSH_DESTINATION 
scp -r SPP.cs $SSH_DESTINATION 
scp -r SPP.csproj $SSH_DESTINATION 
scp -r SPP.sln $SSH_DESTINATION 


