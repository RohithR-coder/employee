pipeline {
    agent any

    environment {
        // Replace with your Docker Hub username
        DOCKER_USER = 'rohithr-coder' 
        APP_NAME = 'employee-app'
    }

    stages {
        stage('Checkout GITHUB') {
            steps {
                // Pulls code from the repo configured in the Jenkins Job
                checkout scm
            }
        }

        stage('Create Docker image') {
            steps {
                script {
                    // Build the image using the Dockerfile in root
                    sh "docker build -t ${DOCKER_USER}/${APP_NAME}:latest ."
                }
            }
        }

        stage('Push to Docker Hub') {
            steps {
                // Ensure you created 'docker-hub-creds' in Jenkins Credentials
                withCredentials([usernamePassword(credentialsId: 'docker-hub-creds', passwordVariable: 'PASS', usernameVariable: 'USER')]) {
                    sh "docker login -u ${USER} -p ${PASS}"
                    sh "docker push ${DOCKER_USER}/${APP_NAME}:latest"
                }
            }
        }

        stage('Create Cluster & Deploy') {
            steps {
                script {
                    // Applies the Kubernetes manifests
                    sh "kubectl apply -f k8s-deployment.yaml"
                }
            }
        }

        stage('Show Deployed Application') {
            steps {
                sh "kubectl get svc payslip-service"
                echo "Access the app using the NodePort listed above."
            }
        }
    }
}
