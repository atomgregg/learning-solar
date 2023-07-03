echo "building"
docker build -t atomgregg/atg-ui:v0.1 .

echo "pushing"
docker push atomgregg/atg-ui:v0.1