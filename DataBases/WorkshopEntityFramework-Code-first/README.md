## Our task is to create a simple Social Network using code-first approach

1. Create the models in the SocialNetwork.Models project

- User: 
	- **Username** Unique with [4,20] length which is required
	- First name with [2,50] length
	- Last name with [2,50] length
	- RegisteredOn field type date
	- It has Messages, Images, Posts
- Post
	- Content with min length 10 which is required
	- PostenOn field type date
	- It has Tagged Users
- Message
	- It is associated with Friendship
	- It has Author
	- Content which is required
	- SentOn field type date which is an index
	- SeenOn field type date which is nullable
- Image
	- ImageUrl which is required
	- FileExtension with max length 4 which is required
	- It has a User
- Friendship
	- It has two users
	- It has an Approved field type boolean which is index
	- FriendsSince type date
	- It has Messages

2. You should create DbContext, Migration, Connection String

3. Please test your database first. Check if everything is ok and the relationships are ok. Make a diagram and look for errors.

3. Import all the data from xml files given in the folder. There are two test files.

4. Search all the needed data in Searcher.cs class. Implement the methods in SocialNetworkService.cs

5. Export all the found data into .json files


 
