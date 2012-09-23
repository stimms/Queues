require 'waz-queues'

WAZ::Storage::Base.establish_connection!(:account_name => "prdc", :access_key => "6mEliBWPnykttQyZsLS9JJIY4xYNWMXLt3AFsH7FIRnkxLjAPkXQk2kvM/uiQnSidRUvY7DdA2OnW8AFRh0scA==")

queue = WAZ::Queues::Queue.ensure("prdc")

queue.enqueue!(Base64.encode64("ruby says hi"))
