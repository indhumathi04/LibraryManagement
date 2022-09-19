use Library

insert into userDetail(userName,email,password) values('Indhumathi','indhu@gmail.com','library@')
select * from userDetail

insert into adminDetail(adminName,adminEmail,adminPassword) values('admin1','admin1@gmail.com','adminxyz1')
select * from adminDetail

insert into booksAvailable(title,genre,author,dateAdded) values('To Kill a Mockingbird','Fiction','Harper Lee','09/15/2022')
insert into booksAvailable(title,genre,author,dateAdded) values('The Book Thief','Fiction','Markus Zusak','09/15/2022')
insert into booksAvailable(title,genre,author,dateAdded) values('All the Light We Cannot See','Fiction','Anthony Doerr','09/15/2022')
insert into booksAvailable(title,genre,author,dateAdded) values('The Nightingale','Fiction','Kristin Hannah','09/15/2022')
insert into booksAvailable(title,genre,author,dateAdded) values('The Alice Network','Fiction','Kate Quinn','09/15/2022')

select * from booksAvailable

select * from booksTransaction

delete from booksTransaction where transId=1

delete from booksAvailable where bookId=5 

update booksAvailable set bookDescription ='The unforgettable novel of a childhood in a sleepy Southern town and the crisis of conscience that rocked it. "To Kill A Mockingbird" became both an instant bestseller and a critical success when it was first published in 1960. It went on to win the Pulitzer Prize in 1961 and was later made into an Academy Award-winning film, also a classic.

Compassionate, dramatic, and deeply moving, "To Kill A Mockingbird" takes readers to the roots of human behavior - to innocence and experience, kindness and cruelty, love and hatred, humor and pathos. Now with over 18 million copies in print and translated into forty languages, this regional story by a young Alabama woman claims universal appeal. Harper Lee always considered her book to be a simple love story. Today it is regarded as a masterpiece of American literature.' where bookId=2

update booksAvailable set imageUrl='https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1492238040i/32051912.jpg' where bookId=8

insert into booksAvailable(title,genre,author,dateAdded,imageUrl) values('Just Another Love Song','Music','Kerry Winfrey','09/16/2022','https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1650843798i/53924127.jpg')