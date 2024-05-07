from django.test import TestCase
from django.core import mail
from .models import User

from users.views.send_mail import send_logging_in_mail, send_welcome_mail, send_created_page_mail

class EmailNotificationTest(TestCase):

    def setUp(self):
        self.user = User.objects.create_user(
            username='testuser',
            email='testuser@example.com',
            password='testpassword',
            first_name='Test'
        )

    def test_send_logging_in_mail(self):

        send_logging_in_mail(self.user)

        self.assertEqual(len(mail.outbox), 1)
        self.assertEqual(mail.outbox[0].subject, 'Welcome to Our Website!')
        self.assertIn('Hello Test,', mail.outbox[0].body)
        self.assertIn('Thank you for logging in.', mail.outbox[0].body)

    def test_send_welcome_mail(self):

        send_welcome_mail(self.user)
        self.assertEqual(len(mail.outbox), 1)
        
        self.assertEqual(mail.outbox[0].subject, 'Welcome to Our Website!')
        self.assertIn('Hello Test,', mail.outbox[0].body)
        self.assertIn('complete registration u need to create your profile', mail.outbox[0].body)

    def test_send_created_page_mail(self):
        send_created_page_mail(self.user)

        self.assertEqual(len(mail.outbox), 1)
        
        self.assertEqual(mail.outbox[0].subject, 'Welcome to Our Website!')
        self.assertIn('Hello Test,', mail.outbox[0].body)
        self.assertIn('You complete registarion with creating up your profile', mail.outbox[0].body)

