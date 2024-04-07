# Generated by Django 5.0.3 on 2024-04-07 09:50

import django.contrib.auth.models
import django.contrib.auth.validators
import django.db.models.deletion
import django.utils.timezone
from django.conf import settings
from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('auth', '0012_alter_user_first_name_max_length'),
    ]

    operations = [
        migrations.CreateModel(
            name='User',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('password', models.CharField(max_length=128, verbose_name='password')),
                ('last_login', models.DateTimeField(blank=True, null=True, verbose_name='last login')),
                ('is_superuser', models.BooleanField(default=False, help_text='Designates that this user has all permissions without explicitly assigning them.', verbose_name='superuser status')),
                ('username', models.CharField(error_messages={'unique': 'A user with that username already exists.'}, help_text='Required. 150 characters or fewer. Letters, digits and @/./+/-/_ only.', max_length=150, unique=True, validators=[django.contrib.auth.validators.UnicodeUsernameValidator()], verbose_name='username')),
                ('first_name', models.CharField(blank=True, max_length=150, verbose_name='first name')),
                ('last_name', models.CharField(blank=True, max_length=150, verbose_name='last name')),
                ('is_staff', models.BooleanField(default=False, help_text='Designates whether the user can log into this admin site.', verbose_name='staff status')),
                ('is_active', models.BooleanField(default=True, help_text='Designates whether this user should be treated as active. Unselect this instead of deleting accounts.', verbose_name='active')),
                ('date_joined', models.DateTimeField(default=django.utils.timezone.now, verbose_name='date joined')),
                ('email', models.EmailField(max_length=254, unique=True)),
                ('groups', models.ManyToManyField(blank=True, help_text='The groups this user belongs to. A user will get all permissions granted to each of their groups.', related_name='user_set', related_query_name='user', to='auth.group', verbose_name='groups')),
                ('user_permissions', models.ManyToManyField(blank=True, help_text='Specific permissions for this user.', related_name='user_set', related_query_name='user', to='auth.permission', verbose_name='user permissions')),
            ],
            options={
                'verbose_name': 'user',
                'verbose_name_plural': 'users',
                'abstract': False,
            },
            managers=[
                ('objects', django.contrib.auth.models.UserManager()),
            ],
        ),
        migrations.CreateModel(
            name='Profile',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('first_name', models.CharField(max_length=100)),
                ('last_name', models.CharField(max_length=100)),
                ('status', models.CharField(choices=[('regular', 'Regular'), ('subscriber', 'Subscriber')], default='regular', max_length=100)),
                ('gender', models.CharField(choices=[('M', 'Male'), ('F', 'Female'), ('O', 'Other')], max_length=200)),
                ('hobby', models.CharField(choices=[('reading', 'Reading'), ('writing', 'Writing'), ('painting', 'Painting'), ('drawing', 'Drawing'), ('photography', 'Photography'), ('cooking', 'Cooking'), ('baking', 'Baking'), ('gardening', 'Gardening'), ('hiking', 'Hiking'), ('camping', 'Camping'), ('traveling', 'Traveling'), ('yoga', 'Yoga'), ('meditation', 'Meditation'), ('running', 'Running'), ('cycling', 'Cycling'), ('swimming', 'Swimming'), ('dancing', 'Dancing'), ('playing_instrument', 'Playing an Instrument'), ('singing', 'Singing'), ('acting', 'Acting'), ('watching_movies', 'Watching Movies'), ('playing_video_games', 'Playing Video Games'), ('board_games', 'Board Games'), ('volunteering', 'Volunteering'), ('DIY_projects', 'DIY Projects'), ('fishing', 'Fishing'), ('bird_watching', 'Bird Watching'), ('collecting', 'Collecting (Stamps, Coins, etc.)'), ('crafting', 'Crafting'), ('sculpting', 'Sculpting'), ('knitting', 'Knitting'), ('sewing', 'Sewing'), ('woodworking', 'Woodworking'), ('programming', 'Programming'), ('learning_languages', 'Learning Languages'), ('skydiving', 'Skydiving'), ('rock_climbing', 'Rock Climbing'), ('surfing', 'Surfing')], max_length=200)),
                ('photo', models.ImageField(blank=True, null=True, upload_to='profile_pics/')),
                ('city', models.CharField(blank=True, max_length=100)),
                ('age', models.PositiveIntegerField(blank=True, null=True)),
                ('description', models.TextField(blank=True)),
                ('verified', models.BooleanField(default=False)),
                ('user', models.OneToOneField(on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL)),
            ],
        ),
    ]
