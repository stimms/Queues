from azure.storage import *

queue_service = QueueService(account_name='prdc', account_key="6mEliBWPnykttQyZsLS9JJIY4xYNWMXLt3AFsH7FIRnkxLjAPkXQk2kvM/uiQnSidRUvY7DdA2OnW8AFRh0scA==")

queue_service.create_queue('prdc')

queue_service.put_message('prdc', base64.b64encode('Hi from python'))