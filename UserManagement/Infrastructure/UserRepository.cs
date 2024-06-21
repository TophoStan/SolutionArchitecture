﻿using UserManagement.Domain;

namespace UserManagement.Infrastructure;

public class UserRepository
{
    private readonly UserMySQLContext _SQLcontext;
    private readonly UserMongoDBContext _MongoDBcontext;

    public UserRepository(UserMySQLContext context, UserMongoDBContext mongoDBcontext)
    {
        _SQLcontext = context;
        _MongoDBcontext = mongoDBcontext;
    }

    public async Task<bool> AddUserAsync(User user)
    {
        try
        {
            await _SQLcontext.Users.AddAsync(user);
            await _SQLcontext.SaveChangesAsync();

            await _MongoDBcontext.SQLToMongoDB();
            return true;
        } catch 
        {
            return false;
        }
        
    }

    public async Task<User?> GetUserAsync(string userId)
    {
        return await _SQLcontext.Users.FindAsync(userId!);
    }
}
