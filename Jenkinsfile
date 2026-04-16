pipeline {
    agent any

    stages {
        stage('Checkout GITHUB') {
            steps {
                checkout scm
            }
        }

        stage('Create Docker image') {
            steps {
                // Ensure there is a space between 'build' and '-t'
                sh "docker build -t rohithr/employee-app:latest ."
            }
        }

        stage('Push to Docker Hub') {
            steps {
                // Use the ID you created in Jenkins Credentials
                withCredentials([usernamePassword(credentialsId: 'docker-hub-creds', passwordVariable: 'PASS', usernameVariable: 'USER')]) {
                    sh "docker login -u ${USER} -p ${PASS}"
                    sh "docker push rohithr/employee-app:latest"
                }
            }
        }

        stage('Create Cluster in Kubernetes') {
            steps {
                // This applies your deployment and service
                sh "kubectl apply -f k8s-deployment.yaml"
            }
        }

        stage('Show Deployed Application') {
            steps {
                sh "kubectl get svc payslip-service"
            }
        }
    }
}
