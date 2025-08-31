import boto3
import os

def download_file_from_s3(bucket_name, file_key, download_path):
    try:
        s3 = boto3.client('s3')

        # Check if file exists
        s3.head_object(Bucket=bucket_name, Key=file_key)
        print(f"File '{file_key}' found in bucket '{bucket_name}'. Downloading...")

        # Download file
        s3.download_file(bucket_name, file_key, download_path)
        print(f"File downloaded successfully to {download_path}")

    except s3.exceptions.NoSuchKey:
        print(f"Error: File '{file_key}' does not exist in bucket '{bucket_name}'.")
    except Exception as e:
        print(f"An error occurred: {e}")

if __name__ == "__main__":
    bucket_name = input("Enter the S3 bucket name: ")
    file_key = input("Enter the file key (file name in bucket): ")
    download_path = input("Enter the local path to save the file: ")

    download_file_from_s3(bucket_name, file_key, download_path)
