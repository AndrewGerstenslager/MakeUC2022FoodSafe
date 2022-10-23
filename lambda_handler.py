import json
import uuid
import pymysql

GET_PATH = '/get_product'
POST_PATH = '/set_profile'

def lambda_handler(event, context):
    print(event)
    if event['rawPath'] == GET_PATH:
        print("Start get request")
        product_id = event['queryStringParameters']['product_id']
        name = event['queryStringParameters']['name']
        connection = pymysql.connect(   user='admin',
                    password='password',
                    host='database-1.cpgdtnokbuou.us-east-2.rds.amazonaws.com',
                    database='sys')
            
        with connection:
            with connection.cursor() as cursor:
                cursor.execute(f'''SELECT TOP 1 FROM users WHERE name like {name};''')
        

        #todo add code to read from open food database

        return connection.cursor()
        
    elif event['rawPath'] == POST_PATH:
        print("Start post request")
        print(event)
        try:
            name = event['queryStringParameters']['name']
            food_allergies = event['queryStringParameters']['food_allergies']
            keto = event['queryStringParameters']['keto']
            chrons = event['queryStringParameters']['chrons']
            gluten_free = event['queryStringParameters']['gluten_free']
            dairy_free = event['queryStringParameters']['dairy_free']
            vegan = event['queryStringParameters']['vegan']
            
            connection = pymysql.connect(   user='admin',
                    password='password',
                    host='database-1.cpgdtnokbuou.us-east-2.rds.amazonaws.com',
                    database='sys')
            
            with connection:
                with connection.cursor() as cursor:
                    cursor.execute(f'''INSERT INTO users(name, food_allergies, keto, 
                            chrons, gluten_free, dairy_free, vegan) 
                            VALUES('{name}', '{food_allergies}', '{keto}', 
                            '{chrons}', '{gluten_free}', '{dairy_free}', '{vegan}') ;''')
            connection.commit()
            connection.close()
        except e:
            return {'status', 'Issue'}
        
        
        return {'status', 'Success'}