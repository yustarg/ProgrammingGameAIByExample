using System.Collections;

public abstract class BaseGameEntity {

    private int m_ID;
    private static int m_iNextValidID;

    private void SetID(int val)
    {
        this.m_ID = val;
        m_iNextValidID = val + 1;
    }

    public int GetID()
    {
        return m_ID;
    }

    public BaseGameEntity(int id)
    {
        SetID(id);
    }

    public abstract void Update();
    public abstract bool HandleMessage(Telegram msg);
}
                                                                             