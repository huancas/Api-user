PGDMP                      |            pruebafinal    16.3    16.3 	    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16397    pruebafinal    DATABASE     ~   CREATE DATABASE pruebafinal WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Spain.1252';
    DROP DATABASE pruebafinal;
                postgres    false            �            1259    16398    Usuarios    TABLE     �   CREATE TABLE public."Usuarios" (
    id integer NOT NULL,
    name text,
    description text,
    username text,
    password text,
    idprofile integer,
    createdate text,
    lastupdate text
);
    DROP TABLE public."Usuarios";
       public         heap    postgres    false            �            1259    16405    Usuarios_id_seq    SEQUENCE     �   ALTER TABLE public."Usuarios" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Usuarios_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    215            �          0    16398    Usuarios 
   TABLE DATA           r   COPY public."Usuarios" (id, name, description, username, password, idprofile, createdate, lastupdate) FROM stdin;
    public          postgres    false    215   #	       �           0    0    Usuarios_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Usuarios_id_seq"', 13, true);
          public          postgres    false    216            Q           2606    16404    Usuarios Usuarios_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Usuarios"
    ADD CONSTRAINT "Usuarios_pkey" PRIMARY KEY (id);
 D   ALTER TABLE ONLY public."Usuarios" DROP CONSTRAINT "Usuarios_pkey";
       public            postgres    false    215            �   -   x�34��M�+�,,M�LL����,.)JL�/B�� ����� ��     